import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getTopicsByDomainId } from "../api/topicApi";
import { Topic } from "../types/Topic";

const TopicsPage: React.FC = () => {
  const { domainId } = useParams();
  const [topics, setTopics] = useState<Topic[]>([]);

  useEffect(() => {
    if (domainId) {
      getTopicsByDomainId(parseInt(domainId))
        .then(setTopics)
        .catch(console.error);
    }
  }, [domainId]);

  return (
    <div className="text-center">
      <h2 className="text-3xl font-bold text-indigo-700 mb-6">
        Subiecte pentru domeniul {domainId}
      </h2>

      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6 max-w-6xl mx-auto">
        {topics.map((topic) => (
          <div
            key={topic.id}
            className="bg-white p-6 rounded-xl shadow hover:shadow-lg border hover:border-indigo-400 transition cursor-pointer"
          >
            <h3 className="text-lg font-semibold text-indigo-600">
              {topic.name}
            </h3>
            <p className="text-gray-600 mt-2">{topic.description || "Fără descriere"}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default TopicsPage;
