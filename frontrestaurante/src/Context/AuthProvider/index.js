import { createContext, useEffect, useState } from "react";
import { getUserLocalStorage, LoginRequest, setUserLocalStorage } from "./util";

export  const AuthContext = createContext({})

export const AuthProvider = ({children}) => {
    const [user, setUser] = useState()

    useEffect(() => {
        const user = getUserLocalStorage()

        if (user) {
            setUser(user)
        }
    },[])

    async function authenticate(nome, telefone) {
        const response = await LoginRequest(nome, telefone)

        const payload = { token: response.token, nome, telefone, perfil: response.perfil }
        
        setUser(payload)
        setUserLocalStorage(payload)
    }

    function logout() {
        setUser(null)
        setUserLocalStorage(null)
    }

    return (
        <AuthContext.Provider value={{...user, authenticate, logout}}>
            {children}
        </AuthContext.Provider>
    )
}