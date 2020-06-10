import React from 'react';
import {Col, Row, Container, ModalBody} from 'react-bootstrap';
import ModalHeader from 'react-bootstrap/ModalHeader';
import ciacho from '../../../assets/img/cake.jpg'


const RecipeCard = (props) => {
    const style = {
        width: "100%",
        height: "auto",
        float: "right",
        display: "block",
        margin: "10px",
        clear: "right"
    };
    return(
    <div className = "RecipeCard">
        <ModalHeader closeButton>
            <Container fluid style={{ paddingLeft: "0", paddingRight: "0" }}>
            <Row>
            <Col style={{ maxWidth: "50%"}}>
            <h2>
                {props.przepis.nazwa}
            </h2>
            </Col>
            <Col style={{ maxWidth: "50%" , paddingRight: "2%", paddingTop: "3px", textAlign: "right"}}>
                trudność: {props.przepis.trudnosc}
            </Col>
            </Row>
            <Row >
                <Col >
                    <p><i>
                    {props.przepis.opis}
                    </i></p>
                </Col>
            </Row>
            </Container>
        </ModalHeader>
        <ModalBody>
            <Container>
                <Row>
                    <Col>
                        <h5> Składniki</h5>
                        <ul>
                            <li>lista składników</li>
                        </ul>
                    </Col>
                    <Col>
                    <img className="img" src = {ciacho} alt = "aj" align = "top" style={style}/>
                    </Col>
                </Row>

            <h5> Wykonanie </h5>
            <p>
            CODY JAKIEŚ TAM CUDA CZY COS
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur id metus id tortor auctor aliquam. Donec risus neque, eleifend sit amet rhoncus quis, volutpat sed diam. Phasellus faucibus eleifend dui, in sodales ipsum laoreet vitae. Suspendisse ac erat varius, sagittis nibh vel, viverra elit. Quisque suscipit eleifend sapien, eu aliquam urna accumsan eu. Donec vulputate arcu et fringilla ornare. Morbi ullamcorper blandit posuere. Aliquam erat volutpat.
            Morbi mollis eleifend massa sit amet dapibus. Curabitur viverra, augue at porttitor facilisis, nisi metus pharetra urna, in tristique tellus metus et nisi. Nam eu nisi turpis. Nulla pulvinar aliquam tincidunt. Cras at nisl enim. Suspendisse sem nunc, ultricies eu scelerisque ut, pulvinar in velit. Mauris quis faucibus tortor, ac faucibus enim. Morbi gravida nunc sit amet varius tincidunt. Pellentesque eu dictum ipsum. Praesent nec iaculis augue, eu aliquam augue. Praesent at rutrum turpis. Suspendisse quis iaculis turpis. Nam vel ex hendrerit, pretium sapien eget, suscipit tellus. Suspendisse at massa sit amet metus maximus ultricies sed sit amet justo. Sed dignissim elementum vehicula. Morbi eget elementum tortor.
            Aenean interdum arcu justo, at malesuada neque sollicitudin ut. Duis at nibh nulla. Praesent euismod, nulla sed mollis iaculis, sapien ligula euismod tortor, ut elementum tortor urna eget purus. Aliquam vitae erat sed turpis sollicitudin convallis ut quis nunc. Sed venenatis elit sapien, sed facilisis ex porttitor sed. Etiam auctor venenatis erat, vel tincidunt enim tristique ut. Cras varius mi sit amet tortor molestie auctor. Praesent nec arcu non eros congue vulputate. Pellentesque at nisl blandit, accumsan enim vel, vulputate ex.
            Donec ullamcorper ornare pretium. Praesent tincidunt quam at hendrerit maximus. Quisque quis elementum dolor. Phasellus nisi orci, accumsan id erat nec, placerat viverra diam. Donec in dignissim tortor, non laoreet tortor. Aliquam tincidunt malesuada eros a bibendum. Cras bibendum urna sit amet enim consequat dignissim. Integer bibendum dui sem, non consectetur eros dignissim interdum. Nullam rhoncus risus erat, vitae vulputate nisi elementum ut. Suspendisse pulvinar consequat massa, at malesuada tellus scelerisque vel. Quisque aliquet, ex in aliquam condimentum, nulla lacus tristique nisl, in pulvinar lectus tortor in ipsum. Vivamus risus massa, tempus vitae ipsum suscipit, efficitur porta augue. Integer iaculis neque at fermentum commodo. Donec eleifend nisl quis tincidunt pretium. Vivamus porta lorem tristique nulla facilisis, vitae feugiat nisi fringilla.
            Phasellus dui quam, finibus in nibh vitae, pulvinar volutpat est. Quisque aliquet lectus tincidunt ipsum gravida egestas. Sed sed ante at sapien varius consequat quis eget.
            </p>

            </Container>
        </ModalBody>

    </div>
    );
}

export default RecipeCard;