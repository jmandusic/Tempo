import { createBrowserHistory } from "history";
import { BrowserRouter } from "react-router-dom";

export const history = createBrowserHistory({ forceRefresh: true });

export default class BrowserHistoryWrapper extends BrowserRouter {
  history;
}
