import {  Container,  Content } from "./styles"
import CardPedido from "../../Components/CardPedido"
import Header from "../../Components/Header"
import { useState } from "react"

function Marmita() {
    const [counter, setCounter] = useState(0)
    const [dayweek, setDayWeek] = useState(new Date().toLocaleString('pt-BR', {weekday: 'long'}))
    const [testeArray, setTesteArray] = useState([])

    

    const handlerCounterPlus = () => {
        setCounter(counter + 1)
        }
    
    const handlerCounterLess = () => {
        if (counter > 0)
        {
            setCounter(counter - 1)
        } 
    }

    const handlerTeste = () => {
        
        setTesteArray(testeArray[0] > 0 ? testeArray[0] += 1 : 1)
        
        
        console.log(testeArray[0])
        console.log(typeof (testeArray[0]))
        console.log(testeArray.length)

    }
    
    return (<>

        <Container>
            <Content>
                
                <Header  title={dayweek}/> 
                <CardPedido title="aqui esta um pedido " value={counter}
                    onClickPlus={handlerCounterPlus} onClickLess={handlerCounterLess} />
                <CardPedido title="aqui esta um pedido " value={testeArray[0]} onClickPlus={handlerTeste}  />
                <CardPedido title="aqui esta um pedido " value={testeArray[1]}  />
                <CardPedido title="aqui esta um pedido " value={testeArray[2]}  />
                <CardPedido title="aqui esta um pedido " value={testeArray[3]}  />
                <CardPedido title="aqui esta um pedido " value={testeArray[4]}  />
                <CardPedido title="aqui esta um pedido " value={testeArray[5]}  />
                                                               
            </Content>
        </Container>
    
    
    </>)
}


export {Marmita}