<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]


<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/jollyperson/survival_server">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Survival Game Server</h3>

  <p align="center">
    A simple (little?) game server based on TCP/IP for a survival client (unity)
    <br />
    <a href="https://github.com/jollyperson/survival_server"><strong>Explore the docs WIP»</strong></a>
    <br />
    <br />
    <a href="https://github.com/jollyperson/survival_server"></a>
    ·
    <a href="https://github.com/jollyperson/survival_server/issues">Report Bug</a>
    ·
    <a href="https://github.com/jollyperson/survival_server/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project


This is the server for my [WIP Survival Game](https://github.com/jollyperson/survival_game/). Currently, the game and server are very very tightly coupled and quite messy. I plan to refactor this and decouple this, releasing the server sepereatly to this implementation.

The basis for this server is currently TCP/IPv4 but plans to update this to RUDP are in way which will greatly decrease packet overhead, decreasing perceived lag between server and client.

Obviously this project is quiet rushed btu this is due to time constraints. v2 will be preplanned with oversights in this issue revamped. 

### Built With

* [.NET](https://dotnet.microsoft.com/download/dotnet-framework)




<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

[.Net v4 or greater.](https://dotnet.microsoft.com/download/dotnet-framework)

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/jollyperson/survival_server.git
   ```
2. Downloand .NET v4

3. Compile and run on default port 5555


<!-- ROADMAP -->
## Roadmap
 Networking
* Decouple server and game logic to provide a reuseable backend

Game
* Implement main game logic ontop of networking architecture
* Add persistent storage (likely SQL based PostRegres?)
* Server authoriative design especially with movement (local prediction ofc)


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License
Still deciding.




<!-- CONTACT -->
## Contact

Harkaran Bual - jollyperson_real@outlook.com

Project Link: [https://github.com/jollyperson/survival_server](https://github.com/jollyperson/survival_server)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* []()
* []()
* []()





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/jollyperson/survival_server.vg?style=for-the-badge
[contributors-url]: https://github.com/JollyPerson/survival_server/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/jollyperson/survival_server.svg?style=for-the-badge
[forks-url]: https://github.com/JollyPerson/survival_server/network/members
[stars-shield]: https://img.shields.io/github/stars/jollyperson/survival_server.svg?style=for-the-badge
[stars-url]: https://github.com/jollyperson/survival_server/stargazers
[issues-shield]: https://img.shields.io/github/issues/jollyperson/survival_server.svg?style=for-the-badge
[issues-url]: https://github.com/jollyperson/survival_server/issues
