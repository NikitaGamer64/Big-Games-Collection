#!/bin/bash
# Скрипт для ручного тестирования Крестики-Нолики

echo "=== Тестирование игры Крестики-Нолики ==="
echo ""
echo "Компиляция..."
dotnet build Games/TicTacToe/TicTacToe.csproj

if [ $? -eq 0 ]; then
    echo ""
    echo "✓ Компиляция успешна!"
    echo ""
    echo "Игра готова к запуску."
    echo "Для запуска игры выполните:"
    echo "  dotnet run --project Games/TicTacToe/TicTacToe.csproj"
else
    echo ""
    echo "✗ Ошибка компиляции!"
    exit 1
fi
