import { useForm } from "react-hook-form";
import { useState } from "react";
import { useNavigate  } from "react-router-dom";
import { api } from "../../Services/Api";
import Input from "../../Components/Input";
import Button from "../../Components/Button";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import {  TitleLogin, Container, Wrapper, CriarText } from "./styles"

const schema = yup.object({
  nome: yup.string().required('Campo obrigatório'),
  telefone: yup.string().required('Campo obrigatório'),
}).required();

function Login() {

  const navigate = useNavigate();
  const handleCriarConta = () => {
    navigate('/criarconta')
      
  }
  

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });
 
  const [cliente, setCliente] = useState({
    id: '',
    nome: '',
    telefone: ''
  })
    
  const handleChange = e => {
    const { name, value } = e.target;
    setCliente({
      ...cliente, [name]: value
    });
    
    console.log(cliente)
  }


  const clienteLoginPost = async (e) => {
    e.preventDefault();
    try {
      delete cliente.id
      if (cliente.nome == null || cliente.telefone == null) {
        alert("Insira o nome e o telefone")
      } else {
        const response = await api.post(`Cliente/Login`, cliente)
        if (response.data.perfil === "Adm") {
          navigate('/administrador')
            
        } else {
          navigate('/pedido')
          
          }
      }
    } 
  catch (error) {
    alert('Falha no Login' + error)
  }
}
    return (
        <>
            <Container>   
                <Wrapper>
                    
                    <TitleLogin>Faça seu Login</TitleLogin>

            <form onSubmit={(clienteLoginPost)}>
                <Input name="nome" onChange={handleChange} errorMessage={errors?.nome?.message}  control={control} placeholder="Nome:" />    
                <Input name="telefone" onChange={handleChange} errorMessage={errors?.telefone?.message} control={control} placeholder="Telefone" />   
                
                <Button title="Login"   type="submit"/>
                <CriarText href="/criarconta"> Criar conta</CriarText>

            </form>
            
                    </Wrapper>   
            </Container>
        
        
        </>

    )
}
export {Login}