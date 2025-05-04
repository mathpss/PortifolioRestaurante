import { Card, TextPedido, ButtonCounter, ContainerButton, ContainerCounter } from "./styles";

export default function CardPedido({title, onClickPlus, onClickLess, value, onChange}){
    return (<>
        <Card>
            <TextPedido>
            {title}

            </TextPedido>

            <ContainerButton>
                
                <ButtonCounter onClick={onClickLess}>-</ButtonCounter>
                <ContainerCounter> <input value={value} onChange={onChange} /></ContainerCounter>                
                <ButtonCounter onClick={onClickPlus}>+</ButtonCounter>


            </ContainerButton>
            
        </Card>
        <hr />
        </>
    ) 

}