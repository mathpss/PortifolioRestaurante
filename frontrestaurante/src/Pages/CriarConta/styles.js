import styled from "styled-components";

export const Container = styled.main`
    width: 100vw;
    height: 100vh;

    
    position: relative;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
`

export const Wrapper = styled.div`
    max-width: 300px;
    max-height: 900px;
    border: solid 2px #F2A516;
    border-radius: 8px;
    padding:  22px;

`

export const TitleLogin = styled.p`
    font-style: normal;
    font-weight: 700;
    font-size 32px;

    margin-bottom: 20px;
    line-height: 44px;
 
`
export const CriarText = styled.a`
    font-style: normal;
    font-weight: 700;
    font-size 14px;
    line-height: 19px;
    color:#F2A516;
    margin-top: 5px;
 
`