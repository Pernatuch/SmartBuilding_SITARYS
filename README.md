# SmartBuilding — мониторинг датчиков здания

## Консольное приложение имитирующее управление датчиками безопасности внутри дома, использует три шаблона проектирования:

**ВЫВОД В КОНСОЛЬ**

<img width="612" height="727" alt="изображение" src="https://github.com/user-attachments/assets/296dc4e6-ead3-4848-bd66-e360a1dfe8fa" />
<img width="605" height="788" alt="изображение" src="https://github.com/user-attachments/assets/818cb60b-a0a1-4b06-8c8a-2cca77b7ff1b" />

**ДИАГРАММА КЛАССОВ**
<img width="2691" height="794" alt="Диаграмма классов" src="https://github.com/user-attachments/assets/c65a7059-ff85-4eee-b515-de35b673e928" />

# Паттерны – структура проекта

## Были применены три основных паттерна

- **Abstract Factory** — позволяет создавать разные комплекты устройств для этажей, не привязывая логику здания к конкретным классам устройств.

<img width="1442" height="504" alt="изображение" src="https://github.com/user-attachments/assets/6c89416b-7701-4cc5-8ed5-680abc49718a" />


- **Observer** — автоматическую рассылку показаний датчиков панели управления, архиву и системе тревоги. Подписчиков можно добавлять и удалять без изменения логики опроса датчиков.

<img width="1006" height="534" alt="изображение" src="https://github.com/user-attachments/assets/c23e05ae-141e-4ff6-b4f6-d83c89c8b92a" />


- **Strategy** — позволяет применять разные правила обнаружения опасности в зависимости от типа показаний и менять алгоритмы тревоги независимо от AlarmSystem.

<img width="1256" height="479" alt="изображение" src="https://github.com/user-attachments/assets/ecb70dd6-fb7d-4a96-ac64-9d28f35343b4" />

## Запуск из терминала

В каталоге с `SmartBuilding.csproj` выполните:

bash
dotnet run
