import { Navigate } from "react-router-dom";
import useAuth from "../hooks/useAuth";

interface ProtectedRouteProps {
    children: React.ReactNode;
}

export default function ProtectedRoute({ children }: ProtectedRouteProps) {
    const { loading, isAuthenticated } = useAuth();

    if (loading) {
    return <div className="flex justify-center items-center h-screen">Loading...</div>;
  }

  if (!isAuthenticated) {
    console.log("User is not authenticated -> redirecting to /auth");
    return <Navigate to="/auth" replace />;
  }

  return <>{children}</>;
}
