# Splatty API

![Build Status](https://github.com/VonderTech/splatty-api/actions/workflows/dotnet.yml/badge.svg)
![Dependabot Status](https://img.shields.io/badge/Dependabot-enabled-brightgreen.svg)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/a9b2ae5ae7a84f96a5f7356764ac35ff)](https://app.codacy.com/gh/VonderTech/splatty-api/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
![GitHub last commit](https://img.shields.io/github/last-commit/VonderTech/splatty-api)
![GitHub issues](https://img.shields.io/github/issues/VonderTech/splatty-api)
[![License: MIT][license_badge]][license_link]

## Description

Splatty is an ASP.NET backend service designed to process videos uploaded via the frontend. It utilizes a series of powerful tools to transform video data into detailed Gaussian splat visualizations. The processing pipeline involves:

- FFmpeg: Extracts individual frames from the uploaded video.
- Colmap: Performs Structure from Motion (SfM) to reconstruct the 3D structure from the extracted frames.
- Gsplat: Generates Gaussian splat representations from the 3D structure data.

## Getting Started

Follow these instructions to set up the project locally.

### Prerequisites

- .NET 8 SDK
- FFmpeg

### Installation

1. **Clone the repository**

   ```sh
   git clone https://github.com/VonderTech/splatty-api.git
    ```

2. ### Navigate to the project directory
   ```sh
   cd your-repo
    ```
3. ### Navigate to the project directory
   ```sh
   dotnet restore
   ```

4. ### Configure environment variables
   ```json
   {
     "ConnectionStrings": {
     "DefaultConnection": "YourDatabaseConnectionString"
    },
      "FFmpegPath": "PathToYourFFmpeg"
    }
   ```
## Running the Development Server
1. **Start the development server**

   ```sh
   dotnet run
    ```

2. ### Open your browser and navigate to
   ```sh
   http://localhost:5000
    ```

## Usage

1. **Upload a Video:**

    - Send a POST request to `/api/upload` with the video file.

2. **Check Processing Status:**

    - Send a GET request to `/api/status/{videoId}` to check the status of the video processing.

3. **Retrieve Processed Result:**

    - Send a GET request to `/api/result/{videoId}` to retrieve the processed Gaussian splat result.

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. **Fork the Project**
2. **Create your Feature Branch (`git checkout -b feature/AmazingFeature`)**
3. **Commit your Changes (`git commit -m 'Add some AmazingFeature'`)**
4. **Push to the Branch (`git push origin feature/AmazingFeature`)**
5. **Open a Pull Request**

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For inquiries, feedback, or collaboration opportunities, please contact [André](mailto:hello@vondertech.com).

Happy coding!

Project Link: [https://github.com/VonderTech/splatty-api](https://github.com/VonderTech/splatty-api)

[license_badge]: https://img.shields.io/badge/license-MIT-blue.svg
[license_link]: https://opensource.org/licenses/MIT
