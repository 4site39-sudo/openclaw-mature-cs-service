# OpenClaw Mature C# Service

Зрелый и полноценный C# сервис для мгновенного выполнения команд из WSL.

## Особенности:
- **Логирование** всех операций в файл
- **Обработка ошибок** с детальными сообщениями
- **Простая компиляция** через compile.bat
- **Автоматическое удаление** command файлов после выполнения

## Структура проекта:
- `Program.cs` - основной код сервиса
- `OpenClawService.csproj` - файл проекта
- `compile.bat` - скрипт компиляции для Windows
- `README.md` - эта документация

## Как использовать:
1. Поместите команду в `C:\OpenClaw\SystemHelper\mature_cmd.txt`
2. Сервис выполнит команду через 100ms
3. Результат будет в `C:\OpenClaw\SystemHelper\mature_result.txt`
4. Логи будут в `C:\OpenClaw\SystemHelper\mature_log.txt`

## Компиляция на Windows:
```bash
compile.bat
```

## Запуск:
```bash
OpenClawMatureService.exe
```
