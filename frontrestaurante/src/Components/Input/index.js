import React from 'react';
import { Controller } from 'react-hook-form';
import { InputContainer, IconContainer, InputText,ErrorText } from './styles'

export default function Input({errorMessage, name, control, ...rest}) {
    return (<>
        <InputContainer >
        <Controller
              name={name}
              control={control}
              rules={{ required: true }}

              render={({field}) => <InputText {...field} {...rest} />}              
              />              
        
        
        </InputContainer>
        {errorMessage ? <ErrorText>{ errorMessage }</ErrorText> : null}
    
    
    
    </>)


}