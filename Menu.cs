using HangmanGame;

namespace MenuGame;

public class Menu
{
    private bool _exit;

    public void Execute()
    {
        _exit = false;
        Console.Clear();

        while (!_exit)
        {
            DisplayMenu();
            string? option = Console.ReadLine();
            ProcessOption(option);
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("           MENU PRINCIPAL        ");
        Console.WriteLine("=================================");
        Console.WriteLine();
        Console.WriteLine("1 - Novo jogo");
        Console.WriteLine("2 - Como jogar");
        Console.WriteLine("3 - Sair");
        Console.WriteLine();
        Console.Write("Escolha uma opção: ");
    }

    private void ProcessOption(string? option)
    {
        switch (option)
        {
            case "1":
                NewGame();
                break;

            case "2":
                HowToPlay();
                break;

            case "3":
                Exit();
                break;

            default:
                InvalidOption();
                break;
        }
    }

    private void NewGame()
    {
        Console.Clear();
        Console.WriteLine("=== NOVO JOGO ===");
        Console.Write("Digite a palavra secreta: ");
        string? word = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(word))
        {
            Console.WriteLine("Palavra inválida!");
            WaitForKey();
            return;
        }

        Console.Clear();
        PlayGame(word);
    }

    private void PlayGame(string word)
    {
        Hangman game = new Hangman(word);
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            DisplayHangman(game.GetRemainingAttempts());
            
            Console.WriteLine($"Palavra: {string.Join(" ", game.GetLetters())}");
            Console.WriteLine($"Tentativas restantes: {game.GetRemainingAttempts()}");
            Console.WriteLine();
            Console.WriteLine("1 - Tentar uma letra");
            Console.WriteLine("2 - Tentar a palavra completa");
            Console.WriteLine("3 - Desistir");
            Console.Write("\nEscolha uma opção: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TryLetter(game);
                    break;

                case "2":
                    TryWord(game);
                    break;

                case "3":
                    gameOver = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(1000);
                    break;
            }

            if (CheckWin(game))
            {
                Console.Clear();
                DisplayHangman(game.GetRemainingAttempts());
                Console.WriteLine($"Palavra: {string.Join(" ", game.GetLetters())}");
                Console.WriteLine("\n PARABÉNS! Você venceu!");
                gameOver = true;
                WaitForKey();
            }
            else if (game.GetRemainingAttempts() <= 0)
            {
                Console.Clear();
                DisplayHangman(game.GetRemainingAttempts());
                Console.WriteLine("GAME OVER! Você perdeu!");
                gameOver = true;
                WaitForKey();
            }
        }
    }

    private void DisplayHangman(int remainingAttempts)
    {
        const int MAX_ATTEMPTS = 6;
        int errors = MAX_ATTEMPTS - remainingAttempts;
        
        Console.WriteLine("\n  +---+");
        Console.WriteLine("  |   |");
        
        // Cabeça (1 erro)
        Console.WriteLine(errors >= 1 ? "  O   |" : "      |");
        
        // Corpo e braços (2-4 erros)
        if (errors >= 4)
            Console.WriteLine(" /|\\  |");
        else if (errors >= 3)
            Console.WriteLine(" /|   |");
        else if (errors >= 2)
            Console.WriteLine("  |   |");
        else
            Console.WriteLine("      |");
        
        // Pernas (5-6 erros)
        if (errors >= 6)
            Console.WriteLine(" / \\  |");
        else if (errors >= 5)
            Console.WriteLine(" /    |");
        else
            Console.WriteLine("      |");
        
        Console.WriteLine("      |");
        Console.WriteLine("=========\n");
    }

    private void TryLetter(Hangman game)
    {
        Console.Write("\nDigite uma letra: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
        {
            Console.WriteLine("Digite apenas uma letra!");
            Thread.Sleep(1500);
            return;
        }

        try
        {
            game.TryLatter(input[0]);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"\n{ex.Message}");
            Thread.Sleep(1500);
        }
    }

    private void TryWord(Hangman game)
    {
        Console.Write("\nDigite a palavra completa: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Palavra inválida!");
            Thread.Sleep(1500);
            return;
        }

        game.TryWord(input);
    }

    private bool CheckWin(Hangman game)
    {
        return !game.GetLetters().Contains('_');
    }

    private void HowToPlay()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("         COMO JOGAR FORCA        ");
        Console.WriteLine("=================================");
        Console.WriteLine();
        Console.WriteLine("OBJETIVO:");
        Console.WriteLine("Descubra a palavra secreta antes de completar o boneco!");
        Console.WriteLine();
        Console.WriteLine("REGRAS:");
        Console.WriteLine("1. Você tem 6 tentativas");
        Console.WriteLine("2. Cada erro adiciona uma parte ao boneco:");
        Console.WriteLine("   - 1º erro: Cabeça");
        Console.WriteLine("   - 2º erro: Corpo");
        Console.WriteLine("   - 3º erro: Braço esquerdo");
        Console.WriteLine("   - 4º erro: Braço direito");
        Console.WriteLine("   - 5º erro: Perna esquerda");
        Console.WriteLine("   - 6º erro: Perna direita (Game Over!)");
        Console.WriteLine();
        Console.WriteLine("3. Você pode tentar letras individuais ou a palavra completa");
        Console.WriteLine("4. Acertar a palavra completa = vitória instantânea!");
        Console.WriteLine("5. Errar a palavra completa = derrota instantânea!");
        Console.WriteLine();
        WaitForKey();
    }

    private void Exit()
    {
        Console.Clear();
        Console.WriteLine("Saindo do jogo... Até logo!");
        _exit = true;
    }

    private void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("Opção inválida! Tente novamente.");
        Console.WriteLine();
    }

    private void WaitForKey()
    {
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
    }
}