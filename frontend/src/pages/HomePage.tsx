import React, { useEffect, useState } from "react";
import { Domain } from "../types/Domain";
import { getDomains } from "../api/domainApi";
import { useNavigate } from "react-router-dom";

const HomePage: React.FC = () => {
  const [domains, setDomains] = useState<Domain[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    getDomains().then(setDomains).catch(console.error);
  }, []);

  return (
    <div className="text-center">
      <h1 className="text-5xl font-extrabold mb-2">
        <span className="text-indigo-600">Micro</span>
        <span className="text-emerald-500">Learn</span>
      </h1>
      <p className="text-lg text-gray-600 mb-10">Select a domain to start learning right away!</p>

      <div className="max-w-6xl mx-auto grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
        {domains.map((domain) => (
          <div
            key={domain.id}
            onClick={() => navigate(`/domain/${domain.id}`)}
            className="bg-white p-6 rounded-2xl shadow-md hover:shadow-xl transition duration-300 cursor-pointer border border-gray-200 hover:border-indigo-500"
          >
            <h2 className="text-xl font-semibold text-indigo-600">{domain.name}</h2>
            <p className="text-gray-600 mt-2">{domain.description || "Fără descriere"}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default HomePage;
