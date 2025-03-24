import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import { useNavigate } from "react-router-dom";
import {  Offcanvas, OffcanvasHeader, OffcanvasBody } from 'reactstrap';
import { GiHamburgerMenu } from "react-icons/gi";


function Home() {
    
    const navigate = useNavigate();

    const handleClickSignIn = () => {
        navigate('/login')
    }


  const [offCanvas, setOffCanvas] = useState(false);
  const abrirFecharOffCanvas = () => {
    setOffCanvas(!offCanvas);
  }

  return (<>
    <div className="App container-fluid">
            <header className=" container px-sm-2">
              <nav className='navbar '>

                    <button className="btn btn-warning" onClick={() => abrirFecharOffCanvas()}  >
                      <GiHamburgerMenu />
          </button>
          <Offcanvas   isOpen={offCanvas} >
    <OffcanvasHeader >
              <div className= "offcanvas-header">                
    <button className="btn btn-warning" onClick={() => abrirFecharOffCanvas()}  >
                      <GiHamburgerMenu />
          </button>
    </div>

              
    </OffcanvasHeader>
    <OffcanvasBody >
              <div className="offcanvas-body">
                

                <button className='btn ' onClick={(handleClickSignIn)}>Fazer Login</button>                
                
        </div>
    </OffcanvasBody>
  </Offcanvas>


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
         <button className='btnpedido btn btn-focus-width ' onClick={(handleClickSignIn)}> Faça seu pedido </button>
        
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

          
          
      
    </div>
    </>);
}

export  {Home};
