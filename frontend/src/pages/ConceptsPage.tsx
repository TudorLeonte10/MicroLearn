import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { Concept } from "../types/Concept";
import axios from "axios";

const ConceptsPage: React.FC = () => {
    const { topicId, topicName } = useParams();
    const [concepts, setConcepts] = useState<Concept[]>([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
            const fetchConcepts = async () => {
                try {
                    const response = await axios.get<Concept[]>(`http://localhost:5114/api/concept/topic/${topicId}`);
                    setConcepts(response.data);
                } catch (error) {
                    console.error("Error fetching concepts:", error);
                } finally {
                    setIsLoading(false);
                }
            };
            fetchConcepts();
    }, [topicId]);

    if (isLoading) {
        return <p className="text-center">Loading...</p>;
    }
     return (
    <div>
      <h1 className="text-3xl font-bold mb-6">Concepts</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {concepts.length === 0 ? (
          <p>No concepts found for this topic.</p>
        ) : (
          concepts.map((c) => (
            <Link
              to={`/concept/${c.id}/details`}
              key={c.id}
              className="block p-6 bg-white rounded-xl shadow hover:shadow-lg transition"
            >
              <h2 className="text-xl font-semibold text-indigo-600">{c.name}</h2>
              <p className="text-gray-600 mt-2">{c.description}</p>
            </Link>
          ))
        )}
      </div>
    </div>
  );
}

export default ConceptsPage;