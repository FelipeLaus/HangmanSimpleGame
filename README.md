# Simple Hangman Game (Jogo da Forca Simples)

> [!NOTE]
> This project is a simple console-based Hangman game developed in C# as a learning exercise.
> 
> Este projeto é um jogo da forca simples para console, desenvolvido em C# como um exercício de aprendizado.

<p align="center">
  <a href="#-english">English</a> •
  <a href="#-português">Português</a>
</p>

---

## 🇬🇧 English

### 🚀 Features

*   **Secret Word**: Start a new game with a secret word defined by a player.
*   **Guessing**: You can guess individual letters or risk guessing the entire word.
*   **Lives**: You have 6 attempts to guess the word. Each mistake draws a part of the hangman figure.
*   **Console Interface**: A simple and intuitive text-based interface.

### 🎮 How to Play

1.  **Objective**: Uncover the secret word before the hangman figure is complete.
2.  **Start**: One player enters the secret word.
3.  **Guessing**: Try to guess the letters that make up the word.
4.  **Mistakes**: For each incorrect letter, a part of the hangman's body is added to the gallows. There are 6 mistakes in total:
    *   1st mistake: Head
    *   2nd mistake: Body
    *   3rd mistake: Left arm
    *   4th mistake: Right arm
    *   5th mistake: Left leg
    *   6th mistake: Right leg (Game Over!)
5.  **Win**: You win if you guess the word before making 6 mistakes.
6.  **Loss**: You lose if you guess the full word incorrectly or make 6 mistakes.

### 🛠️ How to Run

1.  Clone this repository:
    ```bash
    git clone https://github.com/FelipeLaus/HangmanSimpleGame.git
    ```
2.  Navigate to the project directory:
    ```bash
    cd HangmanSimpleGame
    ```
3.  Run the project:
    ```bash
    dotnet run
    ```

---

## 🇧🇷 Português

### 🚀 Funcionalidades

*   **Palavra Secreta**: Inicie um novo jogo com uma palavra secreta definida por um jogador.
*   **Tentativas**: Você pode tentar adivinhar letras individuais ou arriscar a palavra completa.
*   **Vidas**: Você tem 6 tentativas para adivinhar a palavra. Cada erro desenha uma parte do boneco na forca.
*   **Interface de Console**: Uma interface de texto simples e intuitiva.

### 🎮 Como Jogar

1.  **Objetivo**: Descubra a palavra secreta antes que o boneco seja completamente enforcado.
2.  **Início**: Um jogador digita a palavra secreta.
3.  **Adivinhação**: Tente adivinhar as letras que compõem a palavra.
4.  **Erros**: A cada letra errada, uma parte do corpo do boneco é adicionada à forca. São 6 erros no total:
    *   1º erro: Cabeça
    *   2º erro: Corpo
    *   3º erro: Braço esquerdo
    *   4º erro: Braço direito
    *   5º erro: Perna esquerda
    *   6º erro: Perna direita (Fim de Jogo!)
5.  **Vitória**: Você vence se adivinhar a palavra antes de cometer 6 erros.
6.  **Derrota**: Você perde se errar a palavra completa ou cometer 6 erros.

### 🛠️ Como Executar

1.  Clone este repositório:
    ```bash
    git clone https://github.com/FelipeLaus/HangmanSimpleGame.git
    ```
2.  Navegue até o diretório do projeto:
    ```bash
    cd HangmanSimpleGame
    ```
3.  Execute o projeto:
    ```bash
    dotnet run
    ```