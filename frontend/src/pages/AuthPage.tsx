import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { useAuth } from "../context/AuthContext";
import Spinner from "../components/Spinner";

export default function AuthPage() {
  const [mode, setMode] = useState<"login" | "register">("login");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const navigate = useNavigate();
  const {login} = useAuth();

  useEffect(() => {
    if (localStorage.getItem("token")) {
      navigate("/");
    }
  }, [navigate]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsLoading(true);

    try {
      if (mode === "register") {
        const resp = await axios.post("http://localhost:5114/api/auth/register", {
          username,
          email,
          password,
        });

        if (resp.status === 200) {
          toast.success("Registration completed successfully 🎉");
          setMode("login");
          navigate("/auth");
        }
      } else {
        const resp = await axios.post("http://localhost:5114/api/auth/login", {
          emailOrUsername: email || username,
          password,
        });

        if (resp.status === 200) {
          const token = resp.data.accessToken;
          console.log("Token primit de la backend:", token);

          if (token) {
            login(token); 
            toast.success("Login completed successfully 🚀");
        } else {
            toast.error("Token missing in response ❌");
    }
        }
      }
    } catch (err: any) {
      console.error("Auth error:", err);
      toast.error("Authentication failed ❌");
    }
    finally {
        setIsLoading(false);
    }
  };

  return (
  <div className="flex items-center justify-center min-h-screen bg-gradient-to-r from-indigo-600 to-emerald-500">
    <div className="bg-white p-8 rounded-2xl shadow-xl w-full max-w-md">
      <h1 className="text-4xl font-bold text-center mb-6">
        <span className="text-indigo-600">Micro</span>
        <span className="text-emerald-500">Learn</span>
      </h1>

      <div className="flex justify-around mb-6">
        <button
          onClick={() => setMode("login")}
          className={`px-4 py-2 rounded-lg transition ${
            mode === "login"
              ? "bg-indigo-600 text-white"
              : "bg-gray-200 hover:bg-gray-300"
          }`}
        >
          Login
        </button>
        <button
          onClick={() => setMode("register")}
          className={`px-4 py-2 rounded-lg transition ${
            mode === "register"
              ? "bg-emerald-500 text-white"
              : "bg-gray-200 hover:bg-gray-300"
          }`}
        >
          Register
        </button>
      </div>

      {/* Formular */}
      <form onSubmit={handleSubmit} className="flex flex-col gap-4">
        {mode === "register" && (
          <input
            type="text"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            className="border p-2 rounded-lg focus:ring-2 focus:ring-emerald-400"
          />
        )}

        <input
          type={mode === "login" ? "text" : "email"}
          placeholder={mode === "login" ? "Email sau Username" : "Email"}
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="border p-2 rounded-lg focus:ring-2 focus:ring-indigo-400"
        />

        <input
          type="password"
          placeholder="Parola"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          className="border p-2 rounded-lg focus:ring-2 focus:ring-indigo-400"
        />

        <button
            type="submit"
            disabled={isLoading}
            className="bg-indigo-600 text-white py-2 rounded-lg hover:bg-indigo-700 transition disabled:opacity-50"
        >
            {isLoading ? <Spinner /> : mode === "login" ? "Login" : "Register"}
        </button>

      </form>
    </div>
  </div>
);
}
