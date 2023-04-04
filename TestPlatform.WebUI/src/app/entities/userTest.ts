import { Test } from './test';

export interface UserTest {
    test: Test;
    rating: number;
    answers: number[];
    isCompleted: boolean;
    finishTime: Date;
}
