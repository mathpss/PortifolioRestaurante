import { api } from "../../Services/Api";
import { useNavigate } from "react-router-dom";

export const setUserLocalStorage = (user) => {
    localStorage.setItem('user', JSON.stringify(user))
}

export const getUserLocalStorage = () => {
    const json = localStorage.getItem('user')

    if (!json) {
        return null
    }

    const user = JSON.parse(json)

    return user ?? null
}

export const LoginRequest = async (nome, telefone) => {

    try {
        if (nome == null || telefone == null) {
            alert("Insira o nome e o telefone")
        } else {
            const response = await api.post(`Cliente/Login`, {nome, telefone})

            return response.data
        }
    }
    catch (error) {
        alert('Falha no Login' + error)
        return null
    }
}