import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import './App.css';
import { api } from './Services/Api';

function App() {
  
  const [cliente, setCliente] = useState({
    id:'',
    nome: '',
    telefone: ''   
  })
  const [marmita, setMarmita] = useState({ 
    misturas: "",
    guarnicoes: "",
    retiradaEntrega: "",
    tamanho: "",
    data: '', 
    clienteId: '' 
  })
  const [endereco, setEndereco] = useState({ 
    nomeRua: "",
    numeroRua: "",
    bairro: "",
    cidade: "",    
    clienteId: ''
  })
    
  const handleChange = e => {
    const { name, value } = e.target;
    setCliente({
      ...cliente, [name]: value
    });
    
    console.log(cliente)
  }

  const handleChangeMarmita = e => {
    const { name, value } = e.target;
    setMarmita({
      ...marmita, [name]: value
    });
    console.log(marmita)
  }

  const handleChangeEndereco = e => {
    const { name, value } = e.target;
    setEndereco({
      ...endereco, [name]: value
    });
    console.log(endereco)
  }

  const [modalCliente, setmodalCliente] = useState(false);
  const abrirFecharModalCliente = () => {
    setmodalCliente(!modalCliente);
  }
  
  const [modalMarmita, setmodalMarmita] = useState(false);
  const abrirFecharModalMarmita = () => {
    setmodalMarmita(!modalMarmita);
  }

  const [modalEndereco, setmodalEndereco] = useState(false);
  const abrirFecharModalEndereco = () => {
    setmodalEndereco(!modalEndereco);
  }

  const clientePost =  async () => {
    delete cliente.id
    if (cliente.nome == null || cliente.telefone == null) {
      alert("Insira o nome e o telefone")
    } else {
      await api.post(`CriarCliente`, cliente).then(response => {
       sessionStorage.setItem('id', response.data.id)              
      });
      abrirFecharModalMarmita()
      abrirFecharModalCliente() 
    }
  }

  const marmitaPost = async () => {
    marmita.retiradaEntrega = parseInt(marmita.retiradaEntrega);
    marmita.tamanho = parseInt(marmita.tamanho);
    marmita.clienteId = parseInt(sessionStorage.getItem('id'))
    marmita.data = new Date().toISOString()
    await api.post(`CriarMarmita`, marmita)

    abrirFecharModalMarmita();
    abrirFecharModalEndereco();
  
    console.log(marmita);
    console.log(sessionStorage);        
  }

  const EnderecoPost = async () => {    
    endereco.numeroRua = parseInt(endereco.numeroRua);
    endereco.clienteId = parseInt(sessionStorage.getItem('id'))    
    await api.post(`CriarEndereco`, endereco)

    abrirFecharModalEndereco();
  
    console.log(endereco);
    console.log(sessionStorage);        
  }




  return (<>
    <div className="App container-fluid">
            <header className=" container px-sm-2">
              <nav className='navbar '>
              <h1></h1>
                <h1 className='navbar-text text-light text-center'>Cárdapio Segunda-Feira</h1>
                <h1></h1>
            </nav>
            </header>
        <main className="main-content container ">
            <h1>Misturas (2 Opções)</h1>
              <h3 className='mt-3 px-2'>Isca de carne</h3>
            
              <h3 className='mt-3 px-2'>Calabresa Acebolada</h3>
            
              <h3 className='mt-3 px-2'>Linguiça toscana frita</h3>
            
              <h3 className='mt-3 px-2'>Parmegiana de frango</h3>
            
              <h3 className='mt-3 px-2'>Filé de frango empanado</h3>

              <h3 className='mt-3 px-2'>Ovo Frito</h3>
              <hr />
          
            <h1>Guarnições (3 opções)</h1> 

              <h3 className='mt-3 px-2'>Legumes refogado</h3>
              <h3 className='mt-3 px-2'>Abóbora cabutia</h3>
              <h3 className='mt-3 px-2'>Repolho refogado</h3>
              <h3 className='mt-3 px-2'>Salada de ovo c/ maionese</h3>
              <h3 className='mt-3 px-2'>Batata Palha</h3>
              <h3 className='mt-3 px-2'>Macarrão alho e óleo</h3>
              <h3 className='mt-3 px-2'>Farofa do cheff</h3>
              <hr/>

        </main>

      <footer className="footer container  row">
         <button className='btnpedido btn btn-focus-width ' onClick={() => abrirFecharModalCliente()}> Faça seu pedido </button>
        
        <div className='divfooter row '>
          <h3 className='col'>P:R$17,00</h3>
          <h3 className='col'>M:R$20,00</h3>
          <h3 className='col'>G:R$22,00</h3>
        </div>

        <div className='divfooter row '>
          <h3 className='col-12'>Rua: Tijuca, 22 Jd Guanabara</h3>
          <h3 className='col-12'>Esquina com Av Europa</h3>
          
        </div>

      </footer>

      <Modal isOpen={modalCliente}>
        <ModalHeader  className='text-black'>Entre com seus dados</ModalHeader>

        <ModalBody>
          <div className='form-group'>
            <label className='text-black'>Nome:</label>
            <br />
            <input type='text' className='form-control' name='nome'  onChange={handleChange} placeholder="Nome" required></input>
            
            <label className='text-black'>Telefone:</label>
            <br />
            <input type='text' className='form-control' pattern="^[1-9]{2}(?:[2-8]|9[0-9])[0-9]{3}[0-9]{4}$" name='telefone'  onChange={handleChange} placeholder="(xx)xxxxx-xxxx" required></input>
            
          </div>

        </ModalBody>

        <ModalFooter>
          <button className='btn btn-primary' onClick={() => clientePost()}>Ok</button>
          <button className='btn btn-danger' onClick={() => abrirFecharModalCliente()}>Cancelar</button>
        </ModalFooter>

      </Modal>

 
          <Modal isOpen={modalMarmita}>

          <ModalHeader  className='text-black'>Entre com seu pedido</ModalHeader>

              <ModalBody>
                <div className='form-group'>
                  <label className='text-black'>Misturas:</label>
                  <br />
                  <input type='text' className='form-control' name='misturas' onChange={handleChangeMarmita} placeholder="misturas"></input>
                  
                  <label className='text-black'>Guarnições:</label>
                  <br />
                  <input type='text' className='form-control' name='guarnicoes' onChange={handleChangeMarmita} placeholder="Guarnições"></input>
                  
                  <label className='text-black'>retiradaEntrega:</label>
                  <br />
                  <input type='text' className='form-control' name='retiradaEntrega' onChange={handleChangeMarmita} placeholder="retiradaEntrega"></input>
                  
                  <label className='text-black'>Tamanho:</label>
                  <br />
                  <input type='text' className='form-control' name='tamanho' onChange={handleChangeMarmita} placeholder="Tamanho"></input>
                  
                </div>

              </ModalBody>

              <ModalFooter>
                <button className='btn btn-primary' onClick={() => marmitaPost()}>Ok</button>
                <button className='btn btn-danger' onClick={() => abrirFecharModalMarmita()} >Cancelar</button>
              </ModalFooter>


      </Modal>
       
          <Modal isOpen={modalEndereco}>

          <ModalHeader  className='text-black'>Entre com seu endereço</ModalHeader>

              <ModalBody>
                <div className='form-group'>
                  <label className='text-black'>Nome da rua:</label>
                  <br />
                  <input type='text' className='form-control' name='nomeRua' onChange={handleChangeEndereco} placeholder="Nome da rua"></input>
                  
                  <label className='text-black'>Número da rua:</label>
                  <br />
                  <input type='text' className='form-control' name='numeroRua' onChange={handleChangeEndereco} placeholder="Número da rua"></input>
                  
                  <label className='text-black'>Bairro:</label>
                  <br />
                  <input type='text' className='form-control' name='bairro' onChange={handleChangeEndereco} placeholder="Bairro"></input>
                  
                  <label className='text-black'>Cidade:</label>
                  <br />
                  <input type='text' className='form-control' name='cidade' onChange={handleChangeEndereco} placeholder="Cidade"></input>

                </div>

              </ModalBody>

              <ModalFooter>
                <button className='btn btn-primary' onClick={() => EnderecoPost()}>Ok</button>
                <button className='btn btn-danger' onClick={() => abrirFecharModalEndereco()} >Cancelar</button>
              </ModalFooter>


      </Modal>
      
    </div>
    </>);
}

export default App;
