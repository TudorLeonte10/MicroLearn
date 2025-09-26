import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export default function Navbar() {

  const {token, logout} = useAuth();

  return (
    <header className="bg-white shadow">
      <div className="container mx-auto px-4 py-4 flex justify-between items-center">
        <Link to="/" className="text-2xl font-bold">
          <span className="text-indigo-600">Micro</span>
          <span className="text-emerald-500">Learn</span>
        </Link>

        <nav className="space-x-6 flex items-center">
          <a href="#" className="text-gray-600 hover:text-indigo-600">Help</a>
          <a href="#" className="text-gray-600 hover:text-indigo-600">About</a>
          <a href="#" className="text-gray-600 hover:text-indigo-600">Contact</a>

          {token && (
            <button
              onClick={logout}
              className="ml-4 px-4 py-2 bg-red-500 text-white rounded-lg hover:bg-red-600 transition"
            >
              Logout
            </button>
          )}
        </nav>
      </div>
    </header>
  );
}
