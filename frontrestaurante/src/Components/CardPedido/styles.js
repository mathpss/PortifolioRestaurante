import styled from "styled-components";

export const Card = styled.div`
    display: flex; 
    flex-direction: row;
    align-items: center;
    justify-content: space-between;

    padding: 5px;

    height: 60px;
    
    
`

export const TextPedido = styled.p`

        font-style: normal;
        font-weight: 700;
        font-size 32px;
        color: #fff;

`
export const ButtonCounter = styled.button`

    background-color: #F2A516;
    border-radius: 100%;
    position: relative;
    color: #fff;

    width: 35px;
    height: 35px;
`

export const ContainerButton = styled.div`
    margin: 0px 15px;
    display: flex;
    flex-direction: row;
`

export const ContainerCounter = styled.div`
    width: 35px;
    height: 35px;

    input{
        font-style: normal;
        font-weight: 700;
        font-size 32px;
        color: #fff;
        width: 35px;
        height: 35px;
        background-color:rgb(76, 78, 76);
        text-align:center;
        
    }
`
