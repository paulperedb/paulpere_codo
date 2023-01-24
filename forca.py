#importar módulos
from palavras import palavras
from palavras_dicas import palavras_dicas
import random

# Modificado aqui para decidir apenas o index do array
# como palavras e palavras_dicas possuem o mesmo tamanho (vetores paralelos)
# uma vez decidido o index, a gente consegue depois referenciar eles no jogar()
def selecionar_palavra():
    return random.randint(1, len(palavras))

#Iniciar o jogo
def jogar(palavraIndex):
    #Definir algumas variãveis
    palavra = palavras[palavraIndex]
    palavraDica = palavras_dicas[palavraIndex]

    palavra_a_completar="_" * len(palavra) # _ _ _     
    advinhou=False
    letras_utilizadas=[]
    palavras_utilizadas=[]
    tentativas=6
    
    #Boas vinadas ao jogador
    print("Vamos jogar!")
    print(exibir_forca(tentativas))
    print("esta é a palavra: %s" %palavra_a_completar)
    print("Dica: " + palavraDica)
    
    #Enquanto o usuário não adivinhar e ainda houver tentativas
    while not advinhou and tentativas>0:
        
        tentativa=input("Digite uma palavra ou letra para continuar: ").upper()
        
        print(tentativa)
        
        #Tentativa de letra única
        #Verificar se a tentativa é uma única letra
        if len(tentativa) ==1 and tentativa.isalpha():
            #veriricar se a letra já foi utilizada
            if tentativa in letras_utilizadas:
                print("Você já utilizou esta letra antes: %s" %tentativa)
            #verifica se a tentativa não está na palavra
            elif tentativa not in palavra:
                print("A letra %s não está na palavra" %tentativa)
                tentativas -=1
                letras_utilizadas.append(tentativa)
                #Quando a ledtra está na palavra
            else:
                print("Você acertou! A letra %s está na palavra" % tentativa)
                letras_utilizadas.append(tentativa)
                
                #transformar a palavra em uma lista
                palavra_lista=list(palavra_a_completar)
                             
                #verifica onde pode substituir o underline baseado na letra que foi passada
                indices= [i for i, letra in enumerate(palavra) if letra== tentativa]
                for indice in indices:
                    palavra_lista[indice] = tentativa
                    
                palavra_a_completar = "".join(palavra_lista)
                
                if "_" not in palavra_a_completar:
                    advinhou=True
                    
        #Tentativa de palavra completa
        #Quando o usuário tenta advinhar a palavra toda da forca
        elif len(tentativa) == len(palavra) and tentativa.isalpha():
            
            # Palavra já utilizada
            if tentativa in palavras_utilizadas:
                print("Você já utilizou esta palavra %s" % tentativa)
            #Palavra está errada
            elif tentativa != palavra:
                print ("A palavra %s está incorreta" % tentativa)
                tentativas -= 1
                palavras_utilizadas.append(tentativa)
            #Acertou a palavra
            else:
                advinhou=True
                palavra_a_completar=palavra
                                        
        #tentativa inválida
        else:
            print("Tentativa inválida, tente novamente!")
        
        #exibir o status do jogo
        print(exibir_forca(tentativas))
        print(palavra_a_completar)
        
        
    #finaliza o jogo se o usuário advinhou a palavra ou acabaram as tentativas
    if advinhou:
        print("Parabens! você acertou a palavra")
    else:
        print("Acabaram as tentativas, a palavra era: %s" %palavra)
             
#Satus do Jogo
def exibir_forca(tentativas):
    estagios = [  # Fim de jogo
              """
                  --------
                  |      |
                  |      O
                  |     \\|/
                  |      |
                  |     / \\
                  -
              """,
              # Falta 1 tentativa
              """
                  --------
                  |      |
                  |      O
                  |     \\|/
                  |      |
                  |     / 
                  -
              """,
              # Faltam 2 tentativas
              """
                  --------
                  |      |
                  |      O
                  |     \\|/
                  |      |
                  |      
                  -
              """,
              # Faltam 3 tentativas
              """
                  --------
                  |      |
                  |      O
                  |     \\|
                  |      |
                  |     
                  -
              """,
              # Faltam 4 tentativas
              """
                  --------
                  |      |
                  |      O
                  |      |
                  |      |
                  |     
                  -
              """,
              # Faltam 5 tentativas
              """
                  --------
                  |      |
                  |      O
                  |    
                  |      
                  |     
                  -
              """,
              # Estado inicial
              """
                  --------
                  |      |
                  |      
                  |    
                  |      
                  |     
                  -
              """
  ]
    return estagios[tentativas]

# Iniciação do jogo e continuar jogando
def iniciar():
    jogar(selecionar_palavra())

    #Quando acaba o jogo, verifica se o usuário quer continuar jogando
    while input("Jogar novamente? (S/N)").upper() == "S":
        jogar(selecionar_palavra())
    
iniciar()
