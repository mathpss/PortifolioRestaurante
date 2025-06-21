import { useForm } from "react-hook-form";
import { useState } from "react";
import { useNavigate  } from "react-router-dom";
import { api } from "../../Services/Api";
import Input from "../../Components/Input";
import Button from "../../Components/Button";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import {  TitleLogin, Container, Wrapper, CriarText } from "./styles"
import { useAuth } from "../../Context/AuthProvider/useAuth";

const schema = yup.object({
  nome: yup.string().required('Campo obrigatório'),
  telefone: yup.string().required('Campo obrigatório'),
}).required();

function Login() {
  const [nomeForm, setNomeForm] = useState()
  const [telefoneForm, setTelefoneForm] = useState()
  const navigate = useNavigate();
  const auth = useAuth()

  const onFinish = async (e, nome, telefone) => {
    e.preventDefault()
    nome = nomeForm
    telefone = telefoneForm
    try {
      await auth.authenticate(nome, telefone)

        if (auth.perfil === "Adm") {
          navigate('/administrador')      
        } else {
          navigate('/pedido')
        }
                
    } catch (error) {
       alert('Falha no Login' + error)
    }
  }

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
    
  const handleChangeNome = e => {
    const { value } = e.target;
    setNomeForm( value)
  }

  const handleChangeTelefone = e => {
    const { value } = e.target;
    setTelefoneForm( value)
  }

console.log(auth)
    return (
        <>
            <Container>   
                <Wrapper>
                    
                    <TitleLogin>Faça seu Login</TitleLogin>

            <form onSubmit={(onFinish)}>
                <Input name="nome" onChange={handleChangeNome} errorMessage={errors?.nome?.message}  control={control} placeholder="Nome:" />    
                <Input name="telefone" onChange={handleChangeTelefone}  errorMessage={errors?.telefone?.message} control={control} placeholder="Telefone" />   
                
                <Button title="Login"   type="submit"/>
                <CriarText href="/criarconta"> Criar conta</CriarText>

            </form>
            
                    </Wrapper>   
            </Container>
        </>
    )
}
export {Login}