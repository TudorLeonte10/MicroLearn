import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import { motion, AnimatePresence } from "framer-motion";
import { Concept } from "../types/Concept";

export default function ConceptDetailsPage() {
  const { conceptId } = useParams();
  const [concept, setConcept] = useState<Concept | null>(null);
  const [currentStep, setCurrentStep] = useState(0);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchConcept = async () => {
      try {
        const resp = await axios.get<Concept>(`http://localhost:5114/api/concept/${conceptId}`);
        setConcept(resp.data);
      } catch (err) {
        console.error("Error fetching concept:", err);
      }
    };
    fetchConcept();
  }, [conceptId]);

  if (!concept) return <p className="text-center">Loading...</p>;

  // Împărțim detaliile pe paragrafe
const detailSections = concept.details
  ? concept.details.split(/\n\s*\n/)
  : [];



  const isLastStep = currentStep === detailSections.length - 1;

  return (
    <div className="max-w-3xl mx-auto">
      <h1 className="text-3xl font-bold text-indigo-700 mb-6">{concept.name}</h1>

      <div className="relative min-h-[220px]">
        <AnimatePresence mode="wait">
          <motion.div
            key={currentStep}
            initial={{ opacity: 0, x: 80 }}
            animate={{ opacity: 1, x: 0 }}
            exit={{ opacity: 0, x: -80 }}
            transition={{ duration: 0.5 }}
            className="bg-white p-6 rounded-2xl shadow-lg border border-gray-200"
          >
            <p className="text-gray-800 whitespace-pre-line leading-relaxed">
              {detailSections[currentStep]}
            </p>
          </motion.div>
        </AnimatePresence>
      </div>

      {/* Butoane de navigare */}
      <div className="flex justify-between mt-6">
        <button
          onClick={() => setCurrentStep((s) => Math.max(s - 1, 0))}
          disabled={currentStep === 0}
          className="px-4 py-2 rounded-lg bg-gray-200 hover:bg-gray-300 disabled:opacity-50"
        >
          Previous
        </button>

        {!isLastStep ? (
          <button
            onClick={() =>
              setCurrentStep((s) =>
                Math.min(s + 1, detailSections.length - 1)
              )
            }
            className="px-4 py-2 rounded-lg bg-indigo-600 text-white hover:bg-indigo-700"
          >
            Next
          </button>
        ) : (
          <button
            onClick={() => navigate(`/concept/${conceptId}/quiz`)}
            className="px-6 py-2 rounded-lg bg-green-600 text-white hover:bg-green-700"
          >
            Start Quiz
          </button>
        )}
      </div>

      {/* Indicator pași */}
      <div className="text-center mt-4 text-sm text-gray-500">
        Step {currentStep + 1} of {detailSections.length}
      </div>
    </div>
  );
}
