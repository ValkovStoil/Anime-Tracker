class FormComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isCreated: false,
      id: this.props.id,
      editAnime: () => {
        EditAnime(this.state.id);
      },
    };
  }
  render() {
    return (
      <form className="form-container" id="anime-form">
        <h1 className="form-title">Anime</h1>
        <div>
          <span>Name</span>
          <input type="text" id="name" required />
        </div>
        <div>
          <span>Link</span>
          <input type="text" id="link" />
        </div>
        <div>
          <span>Image</span>
          <input type="text" id="image" />
        </div>
        <div>
          <span>Episodes</span>
          <input type="number" id="episodes" />
        </div>
        <div>
          <span>Start Date</span>
          <input id="start-date" type="date" required />
        </div>
        <div className="btn-container">
          <ButtonComponent
            class="confirm"
            title="Ok"
            type="submit"
            clickFunc={
              this.props.endPointType === "POST"
                ? CreateAnime
                : this.state.editAnime
            }
          />
          <ButtonComponent
            class="cancel"
            title="Cancel"
            clickFunc={ReturnToMainPage}
          />
        </div>
      </form>
    );
  }
}

async function CreateAnime() {
  var form = document.getElementById("anime-form");
  function handleForm(event) {
    event.preventDefault();
  }
  form.addEventListener("submit", handleForm);

  var name = document.getElementById("name");
  var link = document.getElementById("link");
  var image = document.getElementById("image");
  var episodes = document.getElementById("episodes");
  var startDate = document.getElementById("start-date");

  const data = {
    name: name.value,
    animeLink: link.value,
    animeImage: image.value,
    numberOfEpisodes: episodes.value,
    startingDate: new Date(startDate.value),
  };

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  };

  await fetch("http://localhost:5168/animes", requestOptions)
    .then((response) => {
      if (!response.ok) {
        const error = (data && data.message) || response.status;
        return Promise.reject(error);
      }
      return response.json();
    })
    .catch((error) => {
      console.error("There was an error!", error);
    });

  name.value = "";
  link.value = "";
  image.value = "";
  episodes.value = "";
  startDate.value = "";
}

async function EditAnime(id) {
  var form = document.getElementById("anime-form");
  function handleForm(event) {
    event.preventDefault();
  }
  form.addEventListener("submit", handleForm);

  var name = document.getElementById("name");
  var link = document.getElementById("link");
  var image = document.getElementById("image");
  var episodes = document.getElementById("episodes");
  var startDate = document.getElementById("start-date");

  const data = {
    name: name.value,
    animeLink: link.value,
    animeImage: image.value,
    numberOfEpisodes: episodes.value,
    startingDate: new Date(startDate.value),
  };

  const requestOptions = {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  };

  await fetch("http://localhost:5168/animes/" + id, requestOptions)
    .then((response) => {
      if (!response.ok) {
        const error = (data && data.message) || response.status;
        return Promise.reject(error);
      }
      return response.json();
    })
    .catch((error) => {
      console.error("There was an error!", error);
    });
  location.reload();
}

function ReturnToMainPage() {
  var hsf = document.getElementById("hsf");
  var bguc = document.getElementById("bguc");
  if (hsf === null) {
    window.location.href = "../../Index.html";
  } else {
    var form = document.getElementById("anime-form");
    function handleForm(event) {
      event.preventDefault();
    }
    form.addEventListener("submit", handleForm);

    bguc.style.display = "none";
    hsf.style.display = "none";
  }
}
