import { useForm } from "react-hook-form";
import { useState } from "react";
import { useNavigate  } from "react-router-dom";
import { api } from "../../Services/Api";
import Input from "../../Components/Input";
import Button from "../../Components/Button";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { TitleLogin, Container, Wrapper, CriarText } from "./styles"

const schema = yup.object({
  nome: yup.string().required('Campo obrigatório'),
  telefone: yup.string().required('Campo obrigatório'),
}).required();

function CriarConta() {
      const navigate = useNavigate();


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

    const clientePost = async (e) => {
        e.preventDefault();
        try { 
            delete cliente.id
            const response = await api.post(`Cliente`, cliente)

        navigate('/pedido')
        
        }
        catch(error)
        {
            alert('Erro ao criar a conta ' + error)
    }
      
  }


    return (<>
    <Container>   
                    <Wrapper>
                        
                        <TitleLogin>Faça seu Login</TitleLogin>
    
                <form onSubmit={(clientePost)}>
                    <Input name="nome" onChange={handleChange} errorMessage={errors?.nome?.message}  control={control} placeholder="Nome:" />    
                    <Input name="telefone" onChange={handleChange} errorMessage={errors?.telefone?.message} control={control} placeholder="Telefone" />   
                    
                    <Button title="Criar conta"   type="submit"/>

    
                </form>
                
                        </Wrapper>   
                </Container>
            
            
    
    </>)
}

export {CriarConta}