import axios from 'axios';
import { getUserLocalStorage } from '../Context/AuthProvider/util';

export const api = axios.create({
    baseURL:'http://localhost:5010/Restaurante/'
})

api.interceptors.request.use(
    (config) => { 
        const user = getUserLocalStorage()

        config.headers.Authorization = user?.token

        return config
    },
    
    (error) => {
        return Promise.reject(error)
    }

)