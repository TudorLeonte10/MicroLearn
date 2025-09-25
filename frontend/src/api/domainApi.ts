import axios from 'axios';
import { Domain } from '../types/Domain';

const BASE_URL = "http://localhost:5114/api";

export const getDomains = async (): Promise<Domain[]> => {
    const response = await axios.get(`${BASE_URL}/domain`);
    return response.data;
}