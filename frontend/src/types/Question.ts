export interface Question {
  id: number;
  questionText: string;
  questionType: string;
  optionsJson?: string;
  correctAnswer: string;
  conceptId: number;
}