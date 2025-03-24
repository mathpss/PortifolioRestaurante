import { ButtonContainer } from './styles'

export default function Button({title, onClick}) {
    return (
      <ButtonContainer  onClick={onClick}>
  
          {title}      
            
      </ButtonContainer>
    )
  }