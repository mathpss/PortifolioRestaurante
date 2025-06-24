import CardEndereco from "../../Components/CardEndereco"
import Header from "../../Components/Header"
import { Container, Wrapper } from "./styles"
import { useLocation } from "react-router-dom"

function Confirmacao() {

    const location = useLocation()

    const { mistura, guarnicao } = location.state

    const contagem = guarnicao.reduce((acc, item) => {
        acc[item] = (acc[item] || 0) + 1;
        return acc;
    }, {});

    const repetidos = Object.entries(contagem)
        .filter(([_, count]) => count > 1)
        .map(([item, count]) => `${count}x ${item}`);

    const exclusivos = guarnicao.filter(item => contagem[item] === 1);

    return (<>
        <Container>
            <Header />
            <CardEndereco title1={"Retirada"} title2={"Entrega"} />

            <Wrapper>
                <h1>Mistura : {mistura[0] === mistura[1] ? `2x ${mistura[0]}` : `${mistura.join(', ')}`}</h1>
                <h1>Guarnições : {exclusivos.length === 3 ? `${exclusivos.join(', ')} `: exclusivos.length === 1 ? `${repetidos}, ${exclusivos}` : `${repetidos}`}</h1>
                <h1>Tamanho:</h1>
                <h1>Quantidade:</h1>

            </Wrapper>

        </Container>

    </>)
}

export { Confirmacao }