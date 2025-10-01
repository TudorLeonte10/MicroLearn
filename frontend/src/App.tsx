import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import TopicsPage from "./pages/TopicsPage";
import AuthPage from "./pages/AuthPage";
import ConceptsPage from "./pages/ConceptsPage";
import QuestionsPage from "./pages/QuestionsPage";
import ConceptDetailsPage from "./pages/ConceptDetailPage";
import ConceptRecapPage from "./pages/ConceptRecapPage";
import { ToastContainer } from "react-toastify";
import ProtectedRoute from "./routes/ProtectedRoute";
import Layout from "./components/Layout";
import { AuthProvider } from "./context/AuthContext";

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Routes>
          <Route
            path="/"
            element={
              <ProtectedRoute>
                <Layout>
                  <HomePage />
                </Layout>
              </ProtectedRoute>
            }
          />
          <Route
            path="/domain/:domainId"
            element={
              <ProtectedRoute>
                <Layout>
                  <TopicsPage />
                </Layout>
              </ProtectedRoute>
            }
          />
          <Route
            path="/topic/:topicId/concepts"
            element={
              <ProtectedRoute>
                <Layout>
                  <ConceptsPage />
                </Layout>
              </ProtectedRoute>
            }
          />
          <Route
            path="/concept/:conceptId/quiz"
            element={
              <ProtectedRoute>
                <Layout>
                  <QuestionsPage />
                </Layout>
              </ProtectedRoute>
            }
          />
          <Route
            path="/concept/:conceptId/details"
            element={
              <ProtectedRoute>
                <Layout>
                  <ConceptDetailsPage />
                </Layout>
              </ProtectedRoute>
            }
          />
          <Route
            path="/concept/:conceptId/recap"
            element={
              <ProtectedRoute>
                <Layout>
                  <ConceptRecapPage />
                </Layout>
              </ProtectedRoute>
            }
          />
          <Route path="/auth" element={<AuthPage />} />
        </Routes>
        <ToastContainer position="top-right" autoClose={3000} />
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
