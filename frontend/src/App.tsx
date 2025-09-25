import React from "react";
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import HomePage from "./pages/HomePage";
import TopicsPage from "./pages/TopicsPage";
import AuthPage from "./pages/AuthPage";
import {ToastContainer} from 'react-toastify';
import ProtectedRoute from './ProtectedRoute';

function App() {
  return (
    <BrowserRouter>
      <div className="min-h-screen bg-gray-100 flex flex-col">
        {/* Navbar */}
        <header className="bg-white shadow">
          <div className="container mx-auto px-4 py-4 flex justify-between items-center">
            <Link to="/" className="text-2xl font-bold">
              <span className="text-indigo-600">Micro</span>
              <span className="text-emerald-500">Learn</span>
            </Link>

            <nav className="space-x-6">
              <a href="#" className="text-gray-600 hover:text-indigo-600">
                Help
              </a>
              <a href="#" className="text-gray-600 hover:text-indigo-600">
                About
              </a>
              <a href="#" className="text-gray-600 hover:text-indigo-600">
                Contact
              </a>
            </nav>
          </div>
        </header>

        {/* Pagina activă */}
        <main className="container mx-auto px-4 py-8 flex-grow">
          <Routes>
            <Route path="/" element={<ProtectedRoute><HomePage /></ProtectedRoute>} />
            <Route path="/domain/:domainId" element={<ProtectedRoute><TopicsPage /></ProtectedRoute>} />
            <Route path="/auth" element={<AuthPage />} />
          </Routes>
        </main>

        {/* Footer */}
        <footer className="bg-white text-center text-sm text-gray-500 py-4">
          © {new Date().getFullYear()} MicroLearn
        </footer>
      </div>
      <ToastContainer position="top-right" autoClose={3000}/>
    </BrowserRouter>
  );
}

export default App;
