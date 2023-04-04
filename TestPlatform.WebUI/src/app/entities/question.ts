import { AnswerOption } from './answerOption';

export interface Question {
    questionNumber: number;
    questionText: string;
    answerOptions: AnswerOption[];
}
