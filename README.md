# 🌲✨ Magic Forest

## 🎮 Descripción del Proyecto

**Magic Forest** es un prototipo de videojuego 2D tipo *side-scroller* desarrollado en Unity.

El jugador controla a un personaje que explora un bosque mágico, lucha contra enemigos y gana experiencia para progresar a lo largo de diferentes escenas.

El objetivo principal del proyecto es aplicar los conceptos técnicos trabajados en clase en el desarrollo de un prototipo funcional.

---

## 🎯 Objetivos del Proyecto

En este prototipo se han implementado las siguientes mecánicas y sistemas requeridos:

* Movimiento del personaje
  * Mover izquierda y derecha
  * Salto
  * Ataque
* Sistema de animaciones
* Recolección de objetos usando la tecnica de pooling
* El uso de Sonido
* Scrolling y Parallax del fondo
* Uso de Tilemap con múltiples capas
* Sistema de UI
* Eventos de juego (colisiones, triggers, UI)
* Control de cámara con Cinemachine

---

## 🧩 Implementación Técnica

### ⭐ Sistema de Jugador y sistema de animaciones
* Uso de Animator Controller con estados:
  * Idle
  * WalkRight (utiliza flix para realizar walkLeft)
  * Attack
  * Death
* Transiciones entre estados
* Uso de **Animation Events** para sincronizar animación y lógica
![alt text](image.png)
---

### 👾 Sistema de Enemigos

* Implementación de diferentes tipos de enemigos
  * Enemigo básico (hace daño cuando colisiona)
  * Enemigo Boss (con ataque frecuentemente)
* Movimiento animaciones de desplazamiento

* Enemigo Básico
  ![alt text](Unity_oYG2hug413.gif)
* Enemigo Boss
  ![alt text](Unity_VftSjPFT5U.gif)
---

### ⭐ Parte del perfil

* Obtener experiencia cuando mata a un enemigo o recolectar objetos
* Perdida de vida cuando un enemigo causa daño al jugador
![alt text](Unity_qSceVfu1d5-1.gif)
---

### 🎁 Object Pooling

* Implementado en la escena de recompensa
* Reutilización de objetos en lugar de instanciación/destrucción constante que ayuda a mejorar el rendimiento y la gestión de memoria
![alt text](Unity_SbhvpjYzZo.gif)
---

### 🌲 Sistema de Tilemap

Uso de Tilemap para la construcción del nivel con varias capas:

* Capa de suelo (colisiones)
  ![alt text](image-1.png)
* Capa de decoración
  ![alt text](image-2.png)
* Capa de elementos interactivos
  ![alt text](image-3.png)

Permite separar la lógica del juego de los elementos visuales.

---

### 🌄 Fondos (Parallax y Scrolling)

* Parallax en la escena principal para simular profundidad
  ![alt text](image-4.png)
  ![alt text](Unity_sEfY9BCDxK.gif)
* Scrolling en la escena de recompensa
  ![alt text](Unity_fB3DEwIiHK.gif)

---

### 🎮 Escenas implementadas

* Menú principal con sistema de inicio y salida del juego  
* Escena principal (bosque en primavera) con exploración, combate y mecánicas principales  
* Escena de recompensa con sistema de recolección y object pooling  


---

### 🧠 Sistema de Eventos

* Eventos basados en colisiones (OnCollision / OnTrigger)
* Eventos de UI (botones, paneles)
* Eventos de juego (puertas, recompensas, fin de nivel)

---

### 🖥️ Interfaz de Usuario (UI)

* Barra de vida
* Barra de experiencia
* Indicador de llave
* Panel de fin de nivel
* Interacción mediante botones

---

### 🎥 Cámara (Cinemachine)

* Uso de Cinemachine Virtual Camera
* Seguimiento del jugador
* Control del encuadre

---

### 🔊 Sistema de Audio

* Uso de AudioMixer para:

  * Música de fondo
  * Efectos de sonido
  * Control general del audio

---

## 🛠️ Tecnologías Utilizadas

* Unity
* C#
* Cinemachine
* Tilemap
* UI System
* AudioMixer

---

## 📊 Relación con la Rúbrica de Evaluación

* **Originalidad** → Concepto narrativo propio
* **Complejidad del mapa** → Uso de Tilemap con múltiples capas
* **Calidad del código** → Scripts organizados por sistemas
* **Complejidad de escenas** → Uso de varias escenas con lógica
* **Interfaz de usuario** → UI funcional y dinámica
* **Animaciones** → Estados múltiples y eventos
* **Cámara** → Implementación con Cinemachine
* **Físicas** → Uso de Rigidbody2D y colisiones
* **Gestión de recursos** → Object Pooling
* **Fondos** → Parallax y scrolling

---

## 🚀 Desarrollo Futuro

### Funcionalidades pendientes

* [ ] Sistema de cartas (selección de mejoras al subir nivel)
* [ ] Sistema de estadísticas (vida, ataque, defensa)
* [ ] Más enemigos y comportamientos
* [ ] Nuevas escenas (verano, otoño, invierno)
* [ ] Mejora de la UI
* [ ] Sistema de guardado

---

## 📌 Estado del Proyecto

🚧 Prototipo funcional (Primera versión completada)

---

## 👩‍💻 Autor

XueMei Lin
Estudiante de Máster en Desarrollo de Videojuegos

---

## 🎥 Portfolio

El proyecto incluye un video explicativo en inglés donde se presenta el prototipo desde una perspectiva técnica.
