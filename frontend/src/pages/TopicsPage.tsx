import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getTopicsByDomainId } from "../api/topicApi";
import { Topic } from "../types/Topic";
import { Link } from "react-router-dom";

const TopicsPage: React.FC = () => {
  const { domainId, domainName } = useParams();
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
        Topics
      </h2>

      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6 max-w-6xl mx-auto">
        {topics.map((topic) => (
  <Link
    key={topic.id}
    to={`/topic/${topic.id}/concepts`}
    className="block bg-white p-6 rounded-xl shadow hover:shadow-lg border hover:border-indigo-400 transition"
  >
    <h3 className="text-lg font-semibold text-indigo-600">{topic.name}</h3>
    <p className="text-gray-600 mt-2">{topic.description || "No description available"}</p>
  </Link>
        ))}
      </div>
    </div>
  );
};

export default TopicsPage;
