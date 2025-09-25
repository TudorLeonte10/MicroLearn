import axios from 'axios';
import { Topic } from '../types/Topic';

const BASE_URL = "http://localhost:5114/api";

export const getAllTopics = async (): Promise<Topic[]> => {
    const response = await axios.get(`${BASE_URL}/topic`);
    return response.data;
}

export const getTopicsByDomainId = async (domainId: number): Promise<Topic[]> => {
  const response = await axios.get(`${BASE_URL}/topic/domain/${domainId}`);
  return response.data;
};
