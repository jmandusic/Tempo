import TempoLogo from "../../assets/TempoLogo.svg";

import "./LandingPage.css";

const LandingPage = () => {
  return (
    <section className="landing__page">
      <img className="landing__page-logo" alt="Tempo Logo" src={TempoLogo} />;
    </section>
  );
};

export default LandingPage;
