import SansAnimation from './SansAnimation';
export default function Header() {

  return (
    <header className="text-center mt-8 undertale-header-layout">
      <SansAnimation />
      <div className="undertale-mainly-headerdiv">
        <h1 className="undertale-mainly-Title">Thomas Chen</h1>
        <p className="undertale-mainly-info">Web Application Engineer</p>
        <p className="undertale-mainly-info">
          <span>Metairie, LA</span>
          <span>t5049477346@gmail.com</span>
          <span>504-947-7346</span>
        </p>
        <p className="undertale-mainly-info">Open to Remote or Relocation | Green Card</p>
      </div>
    </header>
  );
}
