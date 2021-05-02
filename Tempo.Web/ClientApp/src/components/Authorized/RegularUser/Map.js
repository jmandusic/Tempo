import { useEffect, useState } from "react";
import ReactMapGL, { Marker, Popup } from "react-map-gl";
import { Redirect } from "react-router";
import MapMarker from "../../../assets/MapMarker.svg";
import 'mapbox-gl/dist/mapbox-gl.css';
import { getGyms } from "../../../utils/axiosHelper";

const token =
  "pk.eyJ1Ijoiam1hbmR1c2ljIiwiYSI6ImNrbzcwOWlodTAyc2gybnMyajBwa3h6dHMifQ.Ro4T0NnZgf1WJERgOX6UKg";

const defaultState = {
  width: "400px",
  height: "250px",
  latitude: 43.508133,
  longitude: 16.440193,
  zoom: 8,
}

const Map = () => {
  const [gyms, setGyms] = useState([]);
  const [defaultMap, setDefaultMap] = useState(defaultState);
  const [selectedGym, setSelectedGym] = useState({});

  useEffect(() => {
    getGyms().then(res => setGyms(res.data));
  }, [])

  const handleSelectGym = (e, gym) => {
    e.preventDefault();
    setSelectedGym(gym);
  };

  if (!gyms) {
    return <div>Loading...</div>
  }

  if (!selectedGym) {
    console.log(selectedGym)
  return <Redirect to={`/home/gym/${selectedGym.id}`} />;
  }

  return (
    <ReactMapGL
      {...defaultMap}
      mapboxApiAccessToken={token}
      mapStyle="mapbox://styles/mapbox/dark-v10"
      onViewportChange={(state) => setDefaultMap(state)}
    >
      {gyms.map((gym) => (
        console.log(gym),
        <Marker
          key={gym.id}
          latitude={gym.latitude}
          longitude={gym.longitude}
          onClick={() => handleSelectGym(gym)}
        >
          <img alt="Gym Marker" src={MapMarker} />
        </Marker>
      ))}
    </ReactMapGL>
  );
};

export default Map;
