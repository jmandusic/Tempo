import { useState } from "react";
import ReactMapGL, { Marker, Popup } from "react-map-gl";
import MapMarker from "../../../assets/MapMarker.svg";
import { useGyms } from "../../../providers/GymProvider/hooks";

const token =
  "pk.eyJ1Ijoiam1hbmR1c2ljIiwiYSI6ImNrbnZocmNtaDBtcW8ydnFuejgycXV5bnkifQ.nOK8ATX2xHjvG3l5XndQEw";

const Map = () => {
  const [gyms, setGyms] = useGyms();
  const [defaultMap, setDefaultMap] = useState(defaultState);
  const [selectedGym, setSelectedGym] = useState(null);

  const handleSelectGym = (gym) => (e) => {
    e.preventDefault();
    setSelectedGym(gym);
  };

  return (
    <>
      <ReactMapGL
        {...defaultMap}
        mapboxApiAccessToken={token}
        mapStyle="mapbox://styles/mapbox/dark-v10"
        onViewportChange={(state) => setDefaultMap(state)}
      >
        {gyms.map((gym) => (
          <Marker
            key={gym.id}
            latitude={gym.lat}
            longitude={gym.lng}
            onClick={handleSelectGym(gym)}
          >
            <img src={MapMarker} />
          </Marker>
        ))}
      </ReactMapGL>
    </>
  );
};

export default Map;
