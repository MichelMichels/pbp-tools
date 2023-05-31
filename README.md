<a name="readme-top"></a>

<!-- PROJECT SHIELDS -->
 
<h2 align="center">PBP Tools</h2>

  <p align="center">
    Collection of C# classes to work with the <a href="https://www.psdevwiki.com/psp/PBP">PBP file format</a>.
    <br />
    <br />
    <a href="https://github.com/MichelMichels/pbp-tools/issues/new?assignees=&labels=bug&title=">Report Bug</a>
    ·
    <a href="https://github.com/MichelMichels/pbp-tools/issues/new?assignees=&labels=enhancement&title=">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#getting-started">Getting Started</a></li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#versioning">Versioning</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>

<!-- GETTING STARTED -->
## Getting Started

Clone the repository and open the solution inside the `src` folder.

Inside there are 3 projects.

|Project name|Summary|
|---|---|
|`MichelMichels.PSP.PBP`| Class library that contains all the logic. |
|`MichelMichels.PSP.PBPTests`| Contains all tests for the above library. |
|`MichelMichels.PSP.PBP.Gui`| A demo WPF app to use the class library. |

> :warning: The WPF app is WIP.

<!-- USAGE -->
## Usage

Use the `FastPbpUnpack` static class:

```csharp
FastPbpUnpack.Unpack("/path/to/EBOOT.PBP", "/path/to/outputdir/");
```

It's also possible to use the dependency injected classes directly, like `PbpFileUnpacker`, but these need a bit more setup. See the code inside [`FastPbpUnpack.InitializePbpUnpacker`](src/MichelMichels.PSP.Unpacking/FastPbpUnpack.cs) for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- VERSIONING -->
## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/MichelMichels/pbp-tools/tags). 


<!-- CONTRIBUTING -->
## Contributing

1. Fork the Project
2. Choose an issue from the [issues page](https://github.com/MichelMichels/pbp-tools/issues)
3. Create a branch for the issue on your fork
4. Commit your Changes and include the issue number in the commit message (`git commit -m 'Fix #1337 - Fix implemented'`)
5. Push to your forked repository (`git push`)
6. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License and ownership

Code by [Michel Michels](https://github.com/MichelMichels)

[MIT Licensed](LICENSE)


<p align="right">(<a href="#readme-top">back to top</a>)</p>