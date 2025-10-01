import { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { Question } from "../types/Question";
import axios from "axios";

const QuestionsPage: React.FC = () => {
    const {conceptId, conceptName } = useParams();
    const navigate = useNavigate();
    const [questions, setQuestions] = useState<Question[]>([]);
    const [answers, setAnswers] = useState<Record<number, string>>({});
    const [submitted, setSubmitted] = useState(false);
    const [score, setScore] = useState<number | null>(null);

    useEffect(() => {
        const fetchQuestions = async () => {
            try{
                const response = await axios.get<Question[]>(`http://localhost:5114/api/question/concept/${conceptId}`);
                setQuestions(response.data);
            }
            catch(error){
                console.error("Error fetching questions:", error);
            }
        };
        fetchQuestions();
    }, [conceptId]);

    const handleChange = (questionId: number, value: string) => {
        setAnswers(prev => ({...prev, [questionId]: value}));
    };

    const handleSubmit = () => {
    setSubmitted(true);

    let correct = 0;
    questions.forEach(q => {
        if (answers[q.id]?.trim().toLowerCase() === q.correctAnswer.trim().toLowerCase()) {
            correct++;
        }
    });

    setScore(correct);

};

     return (
    <div className="max-w-3xl mx-auto">
      <h1 className="text-3xl font-bold text-indigo-700 mb-6">Quiz</h1>

      {questions.map((q) => {
        const options: string[] = q.optionsJson
          ? JSON.parse(q.optionsJson)
          : [];

        return (
          <div
            key={q.id}
            className="mb-6 p-6 bg-white rounded-xl shadow border"
          >
            <h2 className="text-lg font-semibold mb-4">{q.questionText}</h2>

            {q.questionType === "MCQ" && (
              <div className="space-y-2">
                {options.map((opt, idx) => (
                  <label key={idx} className="block">
                    <input
                      type="radio"
                      name={`q-${q.id}`}
                      value={opt}
                      checked={answers[q.id] === opt}
                      onChange={(e) =>
                        handleChange(q.id, e.target.value)
                      }
                      className="mr-2"
                    />
                    {opt}
                  </label>
                ))}
              </div>
            )}

            {q.questionType === "TrueFalse" && (
              <div className="space-x-4">
                <label>
                  <input
                    type="radio"
                    name={`q-${q.id}`}
                    value="True"
                    checked={answers[q.id] === "True"}
                    onChange={(e) =>
                      handleChange(q.id, e.target.value)
                    }
                    className="mr-2"
                  />
                  True
                </label>
                <label>
                  <input
                    type="radio"
                    name={`q-${q.id}`}
                    value="False"
                    checked={answers[q.id] === "False"}
                    onChange={(e) =>
                      handleChange(q.id, e.target.value)
                    }
                    className="mr-2"
                  />
                  False
                </label>
              </div>
            )}

            {q.questionType === "OpenText" && (
            <input
                type="text"
                value={answers[q.id] || ""}
                onChange={(e) => handleChange(q.id, e.target.value)}
                className="mt-2 w-full p-2 border rounded-lg focus:ring-2 focus:ring-indigo-400"
                placeholder="Type your answer here..."
              />
            )}  

            {q.questionType === "CodeFill" && (
            <textarea
                value={answers[q.id] || ""}
                onChange={(e) => handleChange(q.id, e.target.value)}
                className="mt-2 w-full p-2 border font-mono rounded-lg focus:ring-2 focus:ring-indigo-400"
                placeholder="Complete the code..."
                rows={3}
              />
            )}


            {submitted && (
              <p
                className={`mt-4 font-semibold ${
                  answers[q.id] === q.correctAnswer
                    ? "text-green-600"
                    : "text-red-600"
                }`}
              >
                {answers[q.id] === q.correctAnswer
                  ? "✅ Corect!"
                  : `❌ Greșit. Răspuns corect: ${q.correctAnswer}`}
              </p>
            )}
          </div>
        );
      })}

      {submitted && score !== null && (
        <div className="mt-6 p-4 bg-indigo-100 text-indigo-800 rounded-lg font-semibold">
            You answered {score} out of {questions.length} correctly 🎉
        </div>
      )}
    
      {submitted && (
        <div className="mt-6 text-center">
         <button 
            onClick={() => navigate(`/concept/${conceptId}/recap`)}
            className="bg-indigo-600 text-white px-6 py-2 rounded-lg hover:bg-indigo-700 transition"
          >
            Go to Recap 
          </button>
        </div>
      )}
      {!submitted && questions.length > 0 && (
        <button
          onClick={handleSubmit}
          className="bg-indigo-600 text-white px-6 py-2 rounded-lg hover:bg-indigo-700 transition"
        >
          Trimite răspunsurile
        </button>
      )}
    </div>
    
  );
}

export default QuestionsPage;