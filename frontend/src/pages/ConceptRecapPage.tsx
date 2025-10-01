import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import { Concept } from "../types/Concept";
import { CheckCircle } from "lucide-react";

export default function ConceptRecapPage() {
  const { conceptId } = useParams();
  const [concept, setConcept] = useState<Concept | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchConcept = async () => {
      try {
        const resp = await axios.get<Concept>(
          `http://localhost:5114/api/concept/${conceptId}`
        );
        setConcept(resp.data);
      } catch (err) {
        console.error("Error fetching concept:", err);
      }
    };
    fetchConcept();
  }, [conceptId]);

  if (!concept) return <p className="text-center">Loading...</p>;

  // recap-ul e salvat în DB ca string cu \n între bullets
  const recapPoints = concept.recap ? concept.recap.split("\n") : [];

  return (
    <div className="max-w-2xl mx-auto text-center">
      <h1 className="text-3xl font-bold text-green-600 mb-6">
        Recap: {concept.name}
      </h1>

      <div className="grid gap-4 mb-8 text-left">
        {recapPoints.length > 0 ? (
          recapPoints.map((line, idx) => (
            <div
              key={idx}
              className="flex items-center gap-3 p-4 bg-emerald-100 rounded-lg shadow"
            >
              <CheckCircle className="text-green-600 w-5 h-5 shrink-0" />
              <span className="text-gray-800">
                {line.replace(/^(\?|✅)\s*/, "")}
              </span>
            </div>
          ))
        ) : (
          <p>No recap available.</p>
        )}
      </div>

      <button
        onClick={() => navigate(`/`)}
        className="bg-emerald-600 text-white px-6 py-2 rounded-lg hover:bg-emerald-700 transition"
      >
        Back to HomePage
      </button>
    </div>
  );
}
