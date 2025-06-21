import { Navigate, Outlet } from "react-router-dom"
import { useAuth } from "../../Context/AuthProvider/useAuth"

export const ProtectedLayout = () => {
    const auth = useAuth()

    if (!auth.nome) {
        return <Navigate to='/'/>
    }

    return <Outlet/>
}