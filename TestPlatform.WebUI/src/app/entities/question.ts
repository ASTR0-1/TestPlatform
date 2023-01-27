import { AnswerOption } from './answerOption';

export class Question {
    questionNumber: number | undefined;
    questionText: string | undefined;
    answerOptions: AnswerOption[] | undefined;
}
