import { useEffect, useState } from "react"
import { api } from "../../Services/Api"
import CardPedido from "../../Components/CardPedido"
function Administrador() {
    const [cardapio, setCardapio] = useState([])

    useEffect(() => {

        const listCardapio = async () => {
    
            const response = await api.get(`Cardapio`)

            setCardapio(response.data)
            
        }
            
        listCardapio()

    }, [])

    
    
        

    return (<>
    {cardapio.map(({ id, misturas, guarnicoes }) =>
        (
            <div key={id}>
                {misturas.map((item, index) => (
                    <CardPedido key={index} title={item} />
                )
                )}

                {guarnicoes.map((item, index) => (
                    <CardPedido key={index} title={item}/>
                )
                )}
                
            </div>
            )
        
        )}
        
    </>
);

}


export {Administrador}