import {Fragment} from "react";
import classes from '../../components/Layout/footer.module.css';
import { SiTiktok } from 'react-icons/si';
import { FaFacebookF } from 'react-icons/fa';
import { FiInstagram } from 'react-icons/fi';
import { SiYoutube } from 'react-icons/si';





const Footer= props => {
    return <Fragment>
<footer >
        <div className={classes.container}>
            <div className={classes.row}>
                <div className={classes.footer_col}>
                    <h4>About us</h4>
                    <p>lorem ipsum</p>
                </div>
                <div className={classes.footer_col}>
                    <h4>Konsole</h4>
                    <ul>
                        <li><a href="#">Konsole</a></li>
                    </ul>
                </div>
                <div className={classes.footer_col}>
                    <h4>Kontrolery</h4>
                    <ul>
                        <li><a href="#">Kontrolery</a></li>
                    </ul>
                </div>
                <div className={classes.footer_col}>
                    <h4>Sprzedaj</h4>
                    <ul>
                        <li><a href="#">Sprzedaj</a></li>
                    </ul>
                </div>
                <div className={classes.footer_col}>
                    <h4>Follow us</h4>
                    <div className={classes.social_links}>
                        <a href="#"><SiTiktok/></a>
                        <a href="#"><FaFacebookF/></a>
                        <a href="#"><FiInstagram/></a>
                        <a href="#"><SiYoutube/></a>
                    </div>
                </div>
            </div>
        </div>

    </footer>
    </Fragment>
    
};

export default Footer;