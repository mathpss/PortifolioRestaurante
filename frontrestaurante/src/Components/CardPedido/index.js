import { Card, TextPedido, ButtonCounter, ContainerButton, ContainerCounter } from "./styles";

export default function CardPedido({title, onClick}){
    return (<>
        <Card>
            <TextPedido>
            {title}

            </TextPedido>

            <ContainerButton>
                <ButtonCounter  onClick={onClick}/>
                <ContainerCounter/>
                <ButtonCounter onClick={onClick}/>


            </ContainerButton>
            
        </Card>
        <hr />
        </>
    ) 

}