import { Container, Content } from "./styles"
import CardPedido from "../../Components/CardPedido"
import Header from "../../Components/Header"
import Button from "../../Components/Button"
import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom";
import { api } from "../../Services/Api"

function Marmita() {
    const navigate = useNavigate();
    const dayweek = new Date().toLocaleString('pt-BR', { weekday: 'long' })
    const [cardapio, setCardapio] = useState([])

    const [mistura, setMistura] = useState([])
    const [countMisturas, setCountMisturas] = useState([])

    const [guarnicoes, setGuarnicoes] = useState([])
    const [countGuarnicoes, setCountGuarnicoes] = useState([])

    useEffect(() => {
        const listCardapio = async () => {
            const response = await api.get(`Cardapio`)
            setCardapio(response.data)
        }
        listCardapio()
    }, [])

    useEffect(() => {
        if (cardapio.length > 0) {
            setCountMisturas(Array(cardapio[0].misturas.length).fill(0))
        }
    }, [cardapio])

    useEffect(() => {
        if (cardapio.length > 0) {
            setCountGuarnicoes(Array(cardapio[0].guarnicoes.length).fill(0))
        }
    }, [cardapio])


    const handlerCounterPlusMistura = (index) => {
        const limite = 2
        const copiaArray = [...countMisturas]
        const total = copiaArray.reduce((acumulador, valor) => acumulador + valor, 0)
        if (total < limite) {
            copiaArray[index] += 1
            setCountMisturas(copiaArray)
        }
    }

    const handlerCounterLessMistura = (index) => {
        const copiaArray = [...countMisturas]
        if (copiaArray[index] > 0) {
            copiaArray[index] -= 1
            setCountMisturas(copiaArray)
        }
    }

    const handlerCounterPlusGuarnicao = (index) => {
        const limite = 3
        const copiaArray = [...countGuarnicoes]
        const total = copiaArray.reduce((acumulador, valor) => acumulador + valor, 0)
        if (total < limite) {
            copiaArray[index] += 1
            setCountGuarnicoes(copiaArray)
        }
    }

    const handlerCounterLessGuarnicao = (index) => {
        const copiaArray = [...countGuarnicoes]
        if (copiaArray[index] > 0) {
            copiaArray[index] -= 1
            setCountGuarnicoes(copiaArray)
        }
    }

    const handlerPedido = () =>
    {
        const copiaMistura = [...mistura]
        const copiaGuarnicao = [...guarnicoes]
        cardapio[0].misturas.forEach((item, index) => {
            for (let i = 0; i < countMisturas[index]; i++)
            {
                copiaMistura.push(item)
            }            
        });
        cardapio[0].guarnicoes.forEach((item, index) => {
            for (let i = 0; i < countGuarnicoes[index]; i++)
            {
                copiaGuarnicao.push(item)
            }
        })

        setMistura(copiaMistura)
        setGuarnicoes(copiaGuarnicao)

        navigate('/confirmacao')
    }
    console.log(mistura)
    console.log(guarnicoes)
    return (<>

        <Container>
            <Content>

                <Header title={dayweek} />

                {cardapio.map(({ id, misturas, guarnicoes }) =>
                (
                    <div key={id}>
                        <h2>Misturas</h2>
                        <hr />
                        {misturas.map((item, index) => (<>

                            <CardPedido key={index} title={item} value={countMisturas[index]}
                                onClickPlus={() => handlerCounterPlusMistura(index)}
                                onClickLess={() => handlerCounterLessMistura(index)} />
                        </>)
                        )}
                        <h2>Guarnições</h2>
                        <hr />
                        
                        {guarnicoes.map((item, index) => (
                            <CardPedido key={index} title={item} value={countGuarnicoes[index]}
                                onClickPlus={() => handlerCounterPlusGuarnicao(index)}
                                onClickLess={() => handlerCounterLessGuarnicao(index)}
                            />
                        )
                        )}
                        <Button title={"Finalizar Pedido"} onClick={() =>handlerPedido()}/>                    
                    </div>
                )

                )}

            </Content>
        </Container>

    </>)
}

export { Marmita }


// <div>
//     {cardapio.length > 0 && (
//       <>
//         <h2>Misturas</h2>
//         <ul>
//           {cardapio[0].misturas.map((item, index) => (
//             <li key={index}>{item}</li>
//           ))}
//         </ul>

//         <h2>Guarnições</h2>
//         <ul>
//           {cardapio[0].guarnicoes.map((item, index) => (
//             <li key={index}>{item}</li>
//           ))}
//         </ul>
//       </>
//     )}
//   </div>
