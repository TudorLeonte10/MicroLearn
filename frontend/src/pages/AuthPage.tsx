import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

export default function AuthPage() {
  const [mode, setMode] = useState<"login" | "register">("login");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      if (mode === "register") {
        const resp = await axios.post("http://localhost:5114/api/auth/register", {
          username,
          email,
          password,
        });

        if (resp.status === 200) {
          toast.success("Registration completed successfully 🎉");
          // după register, mergem la login
          setMode("login");
          navigate("/auth");
        }
      } else {
        const resp = await axios.post("http://localhost:5114/api/auth/login", {
          emailOrUsername: email || username,
          password,
        });

        if (resp.status === 200) {
          // 🔥 aici era bugul → backend-ul returnează `accesToken`
          const token = resp.data.accesToken;
          console.log("Token primit de la backend:", token);

          if (token) {
            localStorage.setItem("token", token);
            toast.success("Login completed successfully 🚀");
            navigate("/");
          } else {
            toast.error("Token missing in response ❌");
          }
        }
      }
    } catch (err: any) {
      console.error("Auth error:", err);
      toast.error("Authentication failed ❌");
    }
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
      <div className="bg-white p-6 rounded-xl shadow-md w-96">
        {/* Toggle */}
        <div className="flex justify-around mb-4">
          <button
            onClick={() => setMode("login")}
            className={`px-4 py-2 rounded-lg ${
              mode === "login" ? "bg-blue-500 text-white" : "bg-gray-200"
            }`}
          >
            Login
          </button>
          <button
            onClick={() => setMode("register")}
            className={`px-4 py-2 rounded-lg ${
              mode === "register" ? "bg-blue-500 text-white" : "bg-gray-200"
            }`}
          >
            Register
          </button>
        </div>

        {/* Formular */}
        <form onSubmit={handleSubmit} className="flex flex-col gap-3">
          {mode === "register" && (
            <input
              type="text"
              placeholder="Username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              className="border p-2 rounded"
            />
          )}

          <input
            type={mode === "login" ? "text" : "email"}
            placeholder={mode === "login" ? "Email sau Username" : "Email"}
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            className="border p-2 rounded"
          />

          <input
            type="password"
            placeholder="Parola"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="border p-2 rounded"
          />

          <button
            type="submit"
            className="bg-blue-500 text-white py-2 rounded hover:bg-blue-600"
          >
            {mode === "login" ? "Login" : "Register"}
          </button>
        </form>
      </div>
    </div>
  );
}
