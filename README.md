# Project Los Santos Synergy

Project Los Santos Synergy é um mod para GTA V desenvolvido em C# usando ScriptHookVDotNet, direcionado ao `.NET Framework 4.8`. O objetivo é criar uma nova experiência de jogo com sistemas de IA aprimorados para NPCs e novas interações, fornecendo uma base modular que facilita a expansão com novas features.

## Visão geral
Este projeto implementa um controlador de mods modular (`ModController`) e subsistemas reutilizáveis (por exemplo, `CarSpawn` e `Systems`) que permitem:
- Spawn e customização de veículos em tempo de jogo.
- Detecção de entidades/veículos à frente do jogador via raycast (`Systems.GetVehicleInFrontOfPlayer`).
- Hooks de entrada (teclas), tick do jogo e notificações in-game.
- Infraestrutura para adicionar sistemas de IA aprimorados e novas interações entre NPCs e jogador.

## Principais features
- Modularidade: cada sistema fica em seu próprio namespace/pasta para facilitar manutenção e extensão.
- Utilitários de world interaction: raycasts, spawn de veículos, manipulação de props e entidades.
- Ponto de entrada simples: `EntryPoint` instancia `ModController` que registra eventos.
- Alvo: `.NET Framework 4.8` (compatível com ScriptHookVDotNet usado pelo GTA V).

## Requisitos
- GTA V atualizado.
- ScriptHookV (Alexander Blade).
- ScriptHookVDotNet compatível com sua versão do GTA V.
- Visual Studio (recomendado) com suporte a `.NET Framework 4.8`.
- .NET Framework 4.8 instalado no sistema.

## Roadmap (prioridades)
- Implementar sistemas de IA para comportamento de NPCs (perseguições, evasões, interações sociais).
- Sistema de diálogo/ações contextuais para NPCs próximos.

## WORK IN PROGRESS...
