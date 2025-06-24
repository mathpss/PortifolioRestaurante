import { TextRetirada, Accordion, SwitchContainer, SwitchInput, SwitchSlider, InputText } from "./styles";
import { useState } from "react";

export default function CardEndereco({ title1, title2 }) {

    const [isChecked, setIsChecked] = useState(false);

    return (<>

        <TextRetirada>
            <h1>{title1}</h1>
            <h1>{title2}</h1>
        </TextRetirada>


        <SwitchContainer>
            <SwitchInput
                type="checkbox"
                checked={isChecked}
                onChange={() => setIsChecked(!isChecked)}
            />
            <SwitchSlider />
        </SwitchContainer>

        <Accordion isOpen={isChecked}>
            <p>Insira o local da entrega</p>
            <InputText placeholder="Nome da Rua"/>
            <InputText type="number" placeholder="Número da Rua"/>
            <InputText placeholder="Bairro"/>
            <InputText placeholder="Cidade"/>
        </Accordion>

    </>)
}